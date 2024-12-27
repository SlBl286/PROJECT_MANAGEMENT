"use client";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { z } from "zod";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { registerSchema } from "@/features/auth/schema";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { Avatar, AvatarFallback } from "@/components/ui/avatar";
import { ImageIcon } from "lucide-react";
import { useRef } from "react";
import { useUpload } from "@/features/upload/api/use-upload";
import { useRemove } from "@/features/upload/api/use-remove";
import { useRegsiter } from "../api/use-register";
import { TEMP_IMAGE_URL } from "@/config";
function RegisterForm() {
  const { mutate, isPending } = useRegsiter();
  const { mutate:upload, isPending: uploading } = useUpload();
  const { mutate:removeFile, isPending: removing } = useRemove();

  const inputRef = useRef<HTMLInputElement>(null);
  const form = useForm<z.infer<typeof registerSchema>>({
    resolver: zodResolver(registerSchema),
    defaultValues: {
      username: "",
      name: "",
      password: "",
    },
  });
  const onSubmit = (values: z.infer<typeof registerSchema>) => {
    console.log(values)
    mutate(values,{
      onSuccess: ()=>{

      }
    });
  };
  const handleImageOnChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (file) {
      upload({file : file}, {
        onSuccess(data) {
            console.log(data)
            form.setValue("avatar",data)
        },
        onError(error){
          console.log(error)
        }
      })
    }
    
  };
  const handleImageOnRemove = (fileName : string | undefined) => {
    console.log(fileName)
    if (fileName) {
      removeFile({fileName : fileName}, {
        onSuccess(data, variables, context) {
            console.log(data)
            form.setValue("avatar",undefined)
        },
        onError(error){
          console.log(error)
        }
      })
    }
    
  };
  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)}>
        <div className="flex flex-col gap-y-2">
          <FormField
            control={form.control}
            name="avatar"
            disabled={isPending || uploading || removing}
            render={({ field }) => (
              <div className="flex flex-col gap-y-">
                <div className="flex items-center gap-x-5">
                  {field.value ? (
                    <div className="size-[72px] relative rounded-md overflow-hidden">
                      <img
                        alt="Logo"
                        className="object-cover"
                        src={
                           TEMP_IMAGE_URL+field.value
                        }
                      />
                    </div>
                  ) : (
                    <Avatar className="size-[72px] ">
                      <AvatarFallback>
                        <ImageIcon className="size-[36px] text-neutral-400 " />
                      </AvatarFallback>
                    </Avatar>
                  )}
                  <div className="flex flex-col">
                    <p className="text-sm">Ảnh Đại diện</p>
                    <p className="text-sm text-muted-foreground">
                      JPG, PNG, SVG hoặc JPEG, tối đa 5MB
                    </p>
                    <input
                      className="hidden"
                      type="file"
                      accept=".jpg, .png, .jpeg, .svg"
                      ref={inputRef}
                      onChange={handleImageOnChange}
                      disabled={isPending || uploading}
                    />
                    {!field.value ? (
                      <Button
                        type="button"
                        disabled={isPending}
                        size={"sm"}
                        className="w-fit mt-2 bg-blue-700"
                        onClick={() => {
                          inputRef.current?.click();
                        }}
                      >
                        Chọn ảnh
                      </Button>
                    ) : (
                      <Button
                        type="button"
                        disabled={isPending || removing}
                        variant={"destructive"}
                        size={"sm"}
                        className="w-fit mt-2"
                        onClick={() => {
                          field.onChange(null);
                          if (inputRef.current) {
                            inputRef.current.value = "";
                            handleImageOnRemove(field.value)
                          }
                        }}
                      >
                        Xoá ảnh
                      </Button>
                    )}
                  </div>
                </div>
              </div>
            )}
          />
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
            name="name"
            disabled={isPending}
            render={({ field }) => (
              <FormItem>
                <FormLabel>Họ và tên</FormLabel>
                <FormControl>
                  <Input {...field} placeholder="Nhập tên của bạn" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <div className="basis-full flex gap-x-2">
            <FormField
              control={form.control}
              name="email"
              disabled={isPending}
              render={({ field }) => (
                <FormItem className=" basis-1/2">
                  <FormLabel>Email</FormLabel>
                  <FormControl>
                    <Input {...field} placeholder="Nhập email" />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="phoneNumber"
              disabled={isPending}
              render={({ field }) => (
                <FormItem className=" basis-1/2">
                  <FormLabel>Điện thoại</FormLabel>
                  <FormControl>
                    <Input {...field} placeholder="Nhập điện thoại" />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
          </div>

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
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="confirmPassword"
            disabled={isPending}
            render={({ field }) => (
              <FormItem>
                <FormLabel>Xác nhận mật khẩu</FormLabel>
                <FormControl>
                  <Input
                    {...field}
                    placeholder="Nhập lại mật khẩu"
                    type={"password"}
                  />
                </FormControl>
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
            Đăng ký
          </Button>
        </div>
      </form>
    </Form>
  );
}

export default RegisterForm;
