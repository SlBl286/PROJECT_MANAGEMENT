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
import { Plus } from "lucide-react";
import { useNavigate, useParams } from "react-router-dom";

function IssuesPage() {
  const navigate = useNavigate()
  const { data } = useGetProjects({});
  return (
    <div className="w-full">
      <div className="flex justify-between mb-4">
        <h1 className="text-3xl font-bold">Dự án</h1>
        <Button className="bg-blue-700" size={"lg"}>
          <Plus /> Tạo dự án
        </Button>
      </div>
      <div className="grid grid-cols-1 lg:grid-cols-3 gap-4">
        {data?.projects.map((p) => (
          <Card className=" hover:cursor-pointer hover:bg-gray-700/10" key={p.id} onClick={()=> {
            navigate(p.id)
          }}>
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
    </div>
  );
}

export default IssuesPage;
