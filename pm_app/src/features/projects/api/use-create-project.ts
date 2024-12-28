import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "sonner";
import { Project } from "../types";
import api from "@/api/api";
import { createProjectSchema } from "../schemas";
import { z } from "zod";

export const useCreateProject = () => {
  const queryClient = useQueryClient();
const mutation = useMutation<Project, Error,z.infer<typeof createProjectSchema> >({
    mutationFn: async (form) => {
      console.log(form);
      const respone = await api.post<Project>("/projects", form);
      if (respone.status !== 201) {
        throw new Error("Có lỗi xảy ra khi tạo mới");
      }
      return respone.data;
    },
    onSuccess: () => {
      toast.success("Tạo mới thành công");
      queryClient.invalidateQueries({ queryKey: ["projects"] });
    },
    onError: (e) => {
      toast.error(e.message);
    },
  });

  return mutation;
};
