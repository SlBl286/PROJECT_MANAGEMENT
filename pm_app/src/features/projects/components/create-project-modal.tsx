import CreateProjectForm from "./create-project-form";
import { ResponsiveModal } from "@/components/responsive-modal";
import { useCreateProjectModal } from "../hooks/use-create-project-modal";

export const CreateProjectModal = () => {
  const { isOpen, close, open, setIsOpen } = useCreateProjectModal();
  return (
    <div className="my-1 flex">
      {/* <Button >a</Button> */}
      <a
        onClick={() => {
          open();
        }}
        className="text-sm font-medium text-muted-foreground transition-colors hover:text-primary ml-3 hover:cursor-pointer w-full"
      >
        Dự án
      </a>
      <ResponsiveModal open={isOpen} onOpenChange={setIsOpen} title="Tạo dự án">
        <CreateProjectForm onCancel={close} onSucces={close}/>
      </ResponsiveModal>
    </div>
  );
};
