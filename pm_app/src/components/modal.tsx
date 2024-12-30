"use client";
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogDescription,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import { Separator } from "@/components/ui/separator";
type ModalProps = {
  chidldren: React.ReactNode;
  buttonLabel : string;
  modalTitle: string;
};
const Modal = ({chidldren,buttonLabel,modalTitle}:ModalProps) => {
  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button variant="link" className="w-full flex justify-start">
            {buttonLabel}
        </Button>
      </DialogTrigger>
      <DialogContent className="max-w-3xl">
        <DialogHeader>
          <DialogTitle>{modalTitle}</DialogTitle>
          <DialogDescription></DialogDescription>
        </DialogHeader>
        <div className="py-4">
          <Separator />
        </div>
        <div>{chidldren}</div>
      </DialogContent>
    </Dialog>
  );
};

export default Modal;
