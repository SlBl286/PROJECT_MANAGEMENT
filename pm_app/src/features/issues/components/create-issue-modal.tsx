import Modal from "@/components/modal";
import CreateIssueForm from "./create-issue-form";

export const CreateIssueModal = () => {
  return <Modal chidldren={<CreateIssueForm />} buttonLabel="công việc" modalTitle="Tạo công việc"/>;
};
