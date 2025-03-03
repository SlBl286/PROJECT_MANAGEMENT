import { ResponsiveModal } from "@/components/responsive-modal";
import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { useGetProjects } from "@/features/projects/api/use-get-projects";
import CreateProjectForm from "@/features/projects/components/create-project-form";
import { CreateProjectModal } from "@/features/projects/components/create-project-modal";
import { useCreateProjectModal } from "@/features/projects/hooks/use-create-project-modal";
import { Plus } from "lucide-react";
import { useNavigate, useParams } from "react-router-dom";
function ProjectsPage() {
  const { open, isOpen, setIsOpen } = useCreateProjectModal();
  const navigate = useNavigate();
  const { data } = useGetProjects({});
  return (
    <div className="w-full">
      <div className="flex justify-between mb-4">
        <h1 className="text-3xl font-bold">Dự án</h1>

        <div className="flex my-1">
          <Button
            className="bg-blue-700"
            onClick={() => {
              open();
            }}
          >
            <Plus /> Tạo dự án
          </Button>
        </div>
      </div>
      {data?.projects.length !== 0 ?
      (
<div className="grid grid-cols-1 lg:grid-cols-3 gap-4">
        {data?.projects.map((p) => (
          <Card
            className=" hover:cursor-pointer hover:bg-gray-700/10"
            key={p.id}
            onClick={() => {
              navigate(p.id);
            }}
          >
            <CardHeader className="flex flex-row justify-between">
              <div className="w-9/12 overflow-hidden">
                <CardTitle className="">
                  <span className="text-xl text-muted-foreground">
                    {p.code}
                  </span>{" "}
                  - <span className="text-xl font-bold">{p.name}</span>
                </CardTitle>
                <CardDescription>{p.description}</CardDescription>
              </div>
              <div>
                <Badge>Active</Badge>
              </div>
            </CardHeader>
            <CardContent></CardContent>
          </Card>
        ))}
      </div>
      ): (
        <div className="flex justify-center text-xl md:text-4xl font-semibold text-muted-foreground">Bạn chưa tham gia dự án nào</div>
      )
    }
      
    </div>
  );
}

export default ProjectsPage;
