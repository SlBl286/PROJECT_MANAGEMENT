import { useMutation } from "@tanstack/react-query";
import { toast } from "sonner";
import api from "../../../api/api";
import { removeSchema } from "../schema";
import { z } from "zod";

export const useRemove = () => {

  const mutation = useMutation<string, Error, z.infer<typeof removeSchema>>({
    mutationFn: async (json) => {
      const respone = await api.post<string>("/RemoveFile", json.fileName);
      console.log(respone);
      if (respone.statusText !== "OK") {
        throw new Error("Failed to remove file");
      }

      return respone.data;
    },
    onError: () => {
      toast.error("Failed to remove file");
    },
  });

  return mutation;
};
