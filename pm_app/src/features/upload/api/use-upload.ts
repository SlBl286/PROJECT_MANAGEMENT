import { useMutation } from "@tanstack/react-query";
import { useNavigate } from "react-router-dom";
import { toast } from "sonner";
import api from "../../../api/api";
import { uploadSchema } from "../schema";
import { z } from "zod";

export const useUpload = () => {
  const navigate = useNavigate();

  const mutation = useMutation<string, Error, z.infer<typeof uploadSchema>>({
    mutationFn: async (json) => {
      const respone = await api.post<string>("/UploadFile", json, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      console.log(respone);
      if (respone.statusText !== "OK") {
        throw new Error("Failed to upload file");
      }

      return respone.data;
    },
    onSuccess: () => {
      toast.success("Logged in");
      navigate(0);
    },
    onError: () => {
      toast.error("Failed to log in.");
    },
  });

  return mutation;
};
