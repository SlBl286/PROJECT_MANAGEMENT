"use client"
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
import { PlusIcon } from "lucide-react";
type ModalProps = {
    chidldren: React.ReactNode
}
const Modal = () => {

  return (
    <Dialog>
      <DialogTrigger asChild>
        <Button variant="outline">
          <PlusIcon />
        </Button>
      </DialogTrigger>
      <DialogContent className="max-w-3xl">
        <DialogHeader>
          <DialogTitle>Thêm sản phẩm</DialogTitle>
          <DialogDescription></DialogDescription>
        </DialogHeader>
        <div className="py-4">
          <Separator />
        </div>
        <div>
        
        </div>
      </DialogContent>
    </Dialog>
  );
};

export default Modal;
