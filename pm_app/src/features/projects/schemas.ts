import z from "zod";
export const createProjectSchema = z.object({
  code: z.string().trim().min(1, "Mã dự án không được để trống"),
  name: z.string().min(6, "Tên dự án không được để trống"),
  description: z.string().optional(),
  memberUserIds : z.string().array()
});
