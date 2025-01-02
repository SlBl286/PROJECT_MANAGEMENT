import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";
import { Issue } from "../types";
import api from "@/api/api";
import { createIssueSchema } from "../schemas";
import { z } from "zod";

export const useCreateIssue = () => {
  const queryClient = useQueryClient();
const mutation = useMutation<Issue, Error,z.infer<typeof createIssueSchema> >({
    mutationFn: async (form) => {
      console.log(form);
      const respone = await api.post<Issue>("/issues", form);
      if (respone.status !== 201) {
        throw new Error("Có lỗi xảy ra khi tạo mới");
      }
      return respone.data;
    },
    onSuccess: () => {
      toast.success("Tạo mới thành công");
      queryClient.invalidateQueries({ queryKey: ["issues"] });
    },
    onError: (e) => {
      toast.error(e.message);
    },
  });

  return mutation;
};
