
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
      if(token) {
        throw new Error("Failed to log out")
      }
      return true;
    },
    onSuccess: () => {
      toast.success("Logged out");
      navigate(0);
      queryClient.invalidateQueries({ queryKey: ["current"] });

    },
    onError: () => {
      toast.error("Failed to log out");
    },
  });

  return mutation;
};
