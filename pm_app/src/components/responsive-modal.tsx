import { useMedia } from "react-use";

import { Dialog, DialogContent, DialogTitle } from "@/components/ui/dialog";
import { Drawer, DrawerContent, DrawerHeader, DrawerTitle } from "./ui/drawer";
import { Separator } from "./ui/separator";

type ResponsiveModalProps = {
  children: React.ReactNode;
  open: boolean;
  title : string,
  onOpenChange: (open: boolean) => void;
};

export const ResponsiveModal = ({
  children,
  onOpenChange,
  open,
  title,
}: ResponsiveModalProps) => {
  const isDesktop = useMedia("(min-width: 1024px)", true);

  if (isDesktop) {
    return (
      <Dialog open={open} onOpenChange={onOpenChange}>
        <DialogContent className="max-w-3xl">
        <DialogTitle>{title}</DialogTitle>

      <Separator />
          {children}
        </DialogContent>
      </Dialog>
    );
  }

  return (
    <Drawer open={open} onOpenChange={onOpenChange}>
      <DrawerContent className="px-3 ">
        <DrawerTitle className="text-xl font-semibold mb-2">{title}</DrawerTitle>
        <div className="">
          {children}
        </div>
      </DrawerContent>
    </Drawer>
  );
};
