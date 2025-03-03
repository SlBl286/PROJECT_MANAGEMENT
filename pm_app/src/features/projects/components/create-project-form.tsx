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
import { useCreateProject } from "../api/use-create-project";
import { Separator } from "@/components/ui/separator";
import { Textarea } from "@/components/ui/textarea";
import { MultiSelect, MultiSelectOption } from "@/components/multi-select";
import { useGetUsers } from "@/features/users/api/use-get-users";
interface CreateProjectFormProps {
  onCancel: () => void;
  onSucces?: ()=> void;
}
const CreateProjectForm = ({onCancel,onSucces}:CreateProjectFormProps) => {
  const { mutate, isPending } = useCreateProject();
  const { data: users ,refetch} = useGetUsers({includeMe:false});

  const form = useForm<z.infer<typeof createProjectSchema>>({
    resolver: zodResolver(createProjectSchema),
    defaultValues: {
      code: "",
      name: "",
      description: "",
      memberUserIds: [],
    },
  });

  const onSubmit = (values: z.infer<typeof createProjectSchema>) => {
    mutate(values, {
      onSuccess: ({}) => {
        if(onSucces) onSucces();
        form.reset();
      },
    });
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="w-full">
        <div className="flex flex-col gap-y-4 w-full">
          <FormField
            control={form.control}
            name="code"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Mã dự án</FormLabel>
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
                <FormLabel>Tên dự án</FormLabel>
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
            name="memberUserIds"
            disabled={isPending}
            render={({ field }) => (
              <div>
                <FormLabel>Thành viên</FormLabel>
                <FormItem>
                  <MultiSelect
                    options={users != undefined ? users.users.map((u) => {
                      return { label: u.name, value: u.id };
                    }) : []}
                    selected={field.value}
                    onChange={field.onChange}
                    onOpen={(state)=> {refetch()}}
                    className="w-full"
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
        <div className="flex items-center justify-end gap-x-2">
          <Button
            type="button"
            size={"lg"}
            variant={"secondary"}
            disabled={isPending}
            onClick={()=> {onCancel()}}
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
