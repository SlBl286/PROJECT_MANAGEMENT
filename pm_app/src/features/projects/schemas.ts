import z from "zod";
export const createProjectSchema = z.object({
  code: z.string().trim().min(1, "Username is required"),
  name: z.string().min(6, "Minimum 6 character"),
  description: z.string().min(6, "Minimum 6 character"),
  memberUserIds : z.string().array()
});
