import { useMutation } from "@tanstack/react-query";
import { toast } from "sonner";
import api from "../../../api/api";
import { uploadSchema } from "../schema";
import { z } from "zod";

export const useUpload = () => {

  const mutation = useMutation<string, Error, z.infer<typeof uploadSchema>>({
    mutationFn: async (json) => {
      const respone = await api.post<string>("/UploadFile", json, {
        headers: {
          "Content-Type": "multipart/form-data",
        },
      });
      if (respone.statusText !== "OK") {
        throw new Error("Failed to upload file");
      }
      return respone.data;
    },
    onError: () => {
      toast.error("Failed to upload");
    },
  });

  return mutation;
};
