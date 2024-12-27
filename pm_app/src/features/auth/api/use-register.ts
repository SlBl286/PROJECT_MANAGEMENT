import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import api from "../../../api/api";
import { ACCESS_TOKEN_KEY, REFRESH_TOKEN_KEY } from "@/config";
import { User } from "../types";
import {  registerSchema } from "../schema";
import { z } from "zod";

export const useRegsiter = () => {
  const navigate = useNavigate();

  const mutation = useMutation<string,Error, z.infer<typeof registerSchema>>({
    mutationFn: async (json) => {
      const respone = await api.post<User>("/register", json);
      console.log(respone);
      if (respone.statusText !== "OK") {
        throw new Error("Có lỗi khi đăng ký.");
      }
      localStorage.setItem(ACCESS_TOKEN_KEY, respone.data.token);
      localStorage.setItem(REFRESH_TOKEN_KEY, respone.data.refreshToken);

      return respone.data.token;
    },
    onSuccess: () => {
      toast.success("Đăng ký tài khoản thành công");
      navigate("/auth/login");
    },
    onError: () => {
      toast.error("Có lỗi khi đăng ký.");
    },
  });

  return mutation;
};
