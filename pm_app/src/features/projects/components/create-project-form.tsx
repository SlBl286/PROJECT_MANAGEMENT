"use client";
import { Button } from "@/components/ui/button";
import {
  Form,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { createProjectSchema } from "../schemas";
import { z } from "zod";
import { Input } from "@/components/ui/input";
import { useRef } from "react";
import { useCreateProject } from "../api/use-create-project";
import { Separator } from "@/components/ui/separator";
import { Textarea } from "@/components/ui/textarea";

const CreateProjectForm = () => {
  const { mutate, isPending } = useCreateProject();
  const form = useForm<z.infer<typeof createProjectSchema>>({
    resolver: zodResolver(createProjectSchema),
    defaultValues: {
      code: "",
      name: "",
      description: "",
    },
  });

  const onSubmit = (values: z.infer<typeof createProjectSchema>) => {
    mutate(values, {
      onSuccess: ({}) => {
        form.reset();
      },
    });
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="w-full">
        <div className="flex flex-col md:flex-row gap-y-4 w-full flex-wrap">
          <FormField
            control={form.control}
            name="code"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Mã sản phẩm</FormLabel>
                <FormItem>
                  <Input {...field} />
                </FormItem>
                <FormMessage />
              </div>
            )}
          />
          <FormField
            control={form.control}
            name="name"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Tên sản phẩm</FormLabel>
                <FormItem>
                  <Input {...field} />
                </FormItem>
                <FormMessage />
              </div>
            )}
          />

          <FormField
            control={form.control}
            name="description"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Mô tả</FormLabel>
                <FormItem>
                  <Textarea {...field} />
                </FormItem>
                <FormMessage />
              </div>
            )}
          />

          <FormField
            control={form.control}
            name="members"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Mã vạch</FormLabel>
                <FormItem>
                  <Input
                    onKeyDownCapture={(e) => {
                      if (e.key === "Enter") {
                        e.preventDefault();
                      }
                    }}
                  />
                </FormItem>
                <FormMessage />
              </div>
            )}
          />
        </div>
        <div className="py-4">
          <Separator />
        </div>
        <div className="flex items-center justify-between">
          <Button
            type="button"
            size={"lg"}
            variant={"secondary"}
            disabled={isPending}
          >
            Huỷ bỏ
          </Button>
          <Button
            type="submit"
            size={"lg"}
            variant={"default"}
            disabled={isPending}
            className="bg-blue-500 hover:bg-blue-600"
          >
            Thêm mới
          </Button>
        </div>
      </form>
    </Form>
  );
};

export default CreateProjectForm;
