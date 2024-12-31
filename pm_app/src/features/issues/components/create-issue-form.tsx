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
import { createIssueSchema } from "../schemas";
import { z } from "zod";
import { Input } from "@/components/ui/input";
import { useCreateProject } from "../api/use-create-issue";
import { Separator } from "@/components/ui/separator";
import { useGetUsers } from "@/features/users/api/use-get-users";
import { IssuePriority, IssueType } from "../enums";
import { Combobox } from "@/components/combobox";
import { useGetProjects } from "@/features/projects/api/use-get-projects";
import { useQuill } from 'react-quilljs';
import 'quill/dist/quill.snow.css';
const CreateIssueForm = () => {
  const { quill, quillRef } = useQuill();
  const { mutate, isPending } = useCreateProject();
  const { data: projects, refetch: refreshProjects } = useGetProjects({});
  const { data: users, refetch: refreshUsers } = useGetUsers({
    includeMe: true,
  });

  const form = useForm<z.infer<typeof createIssueSchema>>({
    resolver: zodResolver(createIssueSchema),
    defaultValues: {
      projectId: "",
      title: "",
      priority: IssuePriority.Low,
      type: IssueType.Task,
      assigneeId: "",
    },
  });

  const onSubmit = (values: z.infer<typeof createIssueSchema>) => {
    console.log(quill?.getText());
    console.log(values)
    // mutate(values, {
    //   onSuccess: ({}) => {
    //     form.reset();
    //   },
    // });
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="w-full">
        <div className="flex flex-col gap-y-4 w-full">
          <FormField
            control={form.control}
            name="projectId"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Dự án</FormLabel>
                <FormItem>
                  <Combobox
                    blankLabel="Chọn dự án..."
                    onChange={field.onChange}
                    value={field.value}
                    options={
                      projects != undefined
                        ? projects.projects.map((u) => {
                            return {
                              label: u.code + " - " + u.name,
                              value: u.id,
                            };
                          })
                        : []
                    }
                  />
                </FormItem>
                <FormMessage />
              </div>
            )}
          />
          <FormField
            control={form.control}
            name="title"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel> Tiêu đề</FormLabel>
                <FormItem>
                  <Input {...field} />
                </FormItem>
                <FormMessage />
              </div>
            )}
          />
          <FormField
            control={form.control}
            name="type"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Loại công việc</FormLabel>
                <FormItem>
                  <Combobox
                    onChange={(value)=>{form.setValue("type",parseInt(value))}}
                    value={field.value.toString()}
                    blankLabel="Loại công việc"
                    options={
                     Object.values(IssueType).filter(it=>typeof it === "string").map((v,i)=> {return {label:v.toString() , value :i.toString()}})
                    }
                  />
                </FormItem>
                <FormMessage />
              </div>
            )}
          />
          <FormField
            control={form.control}
            name="priority"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Mức độ ưu tiên</FormLabel>
                <FormItem>
                  <Combobox
                    onChange={(value)=>{form.setValue("priority",parseInt(value))}}
                    value={field.value.toString()}
                    blankLabel="Mức độ ưu tiên"
                    options={
                      Object.values(IssuePriority).filter(it=>typeof it === "string").map((v,i)=> {return {label:v.toString() , value : i.toString()}})
                    }
                  />
                </FormItem>
                <FormMessage />
              </div>
            )}
          />
          <FormField
            control={form.control}
            name="assigneeId"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Giao cho</FormLabel>
                <FormItem>
                  <Combobox
                    onChange={field.onChange}
                    value={field.value}
                    blankLabel="Giao cho"
                    options={
                      users !== undefined
                        ? users.users.map((u) => {
                            return { label: u.name, value: u.id };
                          })
                        : []
                    }
                  />
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
              <div className="h-[300px] overflow-hidden mb-0">
                <FormLabel>Mô tả</FormLabel>
                <FormItem className="overflow-hidden rounded-md">
                  <div ref={quillRef}/>
                </FormItem>
                <FormMessage />
              </div>
            )}
          />
        </div>
        <div className="py-4">
          <Separator />
        </div>
        <div className="flex items-center justify-end gap-x-2">
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

export default CreateIssueForm;
