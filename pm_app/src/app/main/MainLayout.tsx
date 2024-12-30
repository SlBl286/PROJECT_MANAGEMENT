import { Outlet } from "react-router-dom";
import { cn } from "@/lib/utils";
import { ScrollArea } from "@/components/ui/scroll-area";
import { CreateProjectModal } from "@/features/projects/components/create-project-modal";

export default function MainLayout() {

  return (
    <div className="w-screen">
        {/* <ScrollArea className=""> */}
          <div className={cn("p-2")}>
            <Outlet />
          </div>
        {/* </ScrollArea> */}

    </div>
  );
}
