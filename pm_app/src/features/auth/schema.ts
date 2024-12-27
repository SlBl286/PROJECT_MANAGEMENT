import z from "zod";

export const loginSchema = z.object({
  username: z.string().trim().min(1, "Username is required"),
  password: z.string().min(6, "Minimum 6 character"),
});

export const registerSchema = z
  .object({
    username: z.string().trim().min(1, "Tên tài khoản đang để trống"),
    name: z.string().trim().min(2, "Tên phải có tối thiểu 2 ký tự"),
    email: z.union([
      z.string().email("Email chưa đúng dịnh dạng"),
      z.string().optional()
    ]),
    phoneNumber: z.string().optional(),
    avatar: z.string().optional(),
    password: z.string().min(6, "Mật khẩu có tối thiểu 6 ký tự"),
    confirmPassword: z.string(),
  })
  .refine((data) => data.password === data.confirmPassword, {
    message: "Mật khẩu không khớp",
    path: ["confirmPassword"],
  });
