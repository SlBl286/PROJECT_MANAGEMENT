"use client";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { loginSchema } from "@/features/auth/schema";
import { uselogin } from "@/features/auth/api/use-login";
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Eye } from "lucide-react";
function LoginForm() {
  const { mutate, isPending } = uselogin();

  const form = useForm<z.infer<typeof loginSchema>>({
    resolver: zodResolver(loginSchema),
    defaultValues: {
      username: "",
      password: "",
    },
  });
  const onSubmit = (values: z.infer<typeof loginSchema>) => {
    mutate(values);
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)}>
        <div className="flex flex-col gap-y-4">
          <FormField
            control={form.control}
            name="username"
            disabled={isPending}
            render={({ field }) => (
              <FormItem>
                <FormLabel>Tài khoản</FormLabel>
                <FormControl>
                  <Input {...field} placeholder="Nhập tài khoản" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="password"
            disabled={isPending}
            render={({ field }) => (
              <FormItem>
                <FormLabel>Mật khẩu</FormLabel>
                <FormControl>
                  <Input
                    {...field}
                    placeholder="Nhập mật khẩu"
                    type={"password"}
                  />
                </FormControl>
                <FormDescription>
                  <Button
                    variant={"link"}
                    className="bg-transparent"
                    type="button"
                  >
                    <Eye />
                    hiển thị mật khẩu
                  </Button>
                </FormDescription>
                <FormMessage />
              </FormItem>
            )}
          />
        </div>
        <div className="flex items-center justify-between mt-4">
          <Button
            type="submit"
            size={"lg"}
            disabled={isPending}
            className="w-full bg-blue-700 font-bold text-md"
          >
            Đăng nhập
          </Button>
        </div>
      </form>
    </Form>
  );
}

export default LoginForm;
