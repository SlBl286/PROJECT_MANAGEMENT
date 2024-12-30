import Modal from "@/components/modal";
import CreateProjectForm from "./create-project-form";

export const CreateProjectModal = () => {
  return <Modal chidldren={<CreateProjectForm />} buttonLabel="Dự án" modalTitle="Tạo dự án mới"/>;
};
