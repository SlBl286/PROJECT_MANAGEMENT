import { Outlet } from "react-router-dom";
import { cn } from "@/lib/utils";
import { ScrollArea } from "@/components/ui/scroll-area";

export default function MainLayout() {

  return (
    <div className="flex w-screen">

        <ScrollArea className="">
          <div className={cn("p-2")}>
            <Outlet />
          </div>
        </ScrollArea>

    </div>
  );
}
