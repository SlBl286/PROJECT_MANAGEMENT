import { Outlet } from "react-router-dom";
import { cn } from "@/lib/utils";
import { ScrollArea } from "@/components/ui/scroll-area";
import { CreateProjectModal } from "@/features/projects/components/create-project-modal";
import { Header } from "@/components/header";
import { AssignedIssues } from "@/components/assigned-issues";
import { RecentActivity } from "@/components/recent-activity";
import { ProjectStats } from "@/components/project-stats";
import { QuickLinks } from "@/components/quick-links";

export default function MainLayout() {

  return (
    <div className="min-h-screen bg-background w-screen">
      <Header />
      <main className="container mx-auto p-4 md:p-6">
       <Outlet/>
      </main>
    </div>
    // <div className="w-screen">
    //     {/* <ScrollArea className=""> */}
    //       <div className={cn("p-2")}>
    //         <Outlet />
    //       </div>
    //     {/* </ScrollArea> */}

    // </div>
  );
}
