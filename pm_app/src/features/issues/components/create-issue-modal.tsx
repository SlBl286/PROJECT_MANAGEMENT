import CreateIssueForm from "./create-issue-form";
import { ResponsiveModal } from "@/components/responsive-modal";
import { useCreateIssueModal } from "../hooks/use-create-issue-modal";

export const CreateIssueModal = () => {
  const { isOpen, close, open, setIsOpen } = useCreateIssueModal();
  return (
    <div className="flex my-1">
      {/* <Button >a</Button> */}
      <a
        onClick={() => {
          open();
        }}
        className="text-sm font-medium text-muted-foreground transition-colors hover:text-primary ml-3 hover:cursor-pointer w-full"
      >
        Công việc
      </a>
      <ResponsiveModal open={isOpen} onOpenChange={setIsOpen} title="Tạo công việc">
        <CreateIssueForm onCancel={close} />
      </ResponsiveModal>
    </div>
  );};
