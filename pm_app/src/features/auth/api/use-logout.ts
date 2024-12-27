import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";
import { useNavigate } from "react-router-dom";
import { ACCESS_TOKEN_KEY, REFRESH_TOKEN_KEY } from "@/config";

export const useLogout = () => {
  const navigate = useNavigate();

  const queryClient = useQueryClient();
  const mutation = useMutation({
    mutationFn: async () => {
      localStorage.removeItem(ACCESS_TOKEN_KEY);
      localStorage.removeItem(REFRESH_TOKEN_KEY);
      var token = localStorage.getItem(ACCESS_TOKEN_KEY);
      if (token) {
        throw new Error("Có lỗi khi đăng xuất");
      }
      return true;
    },
    onSuccess: () => {
      toast.success("Đã đăng xuất khỏi tài khoản");
      navigate(0);
      queryClient.invalidateQueries({ queryKey: ["current"] });
    },
    onError: () => {
      toast.error("Có lỗi khi đăng xuất");
    },
  });

  return mutation;
};
