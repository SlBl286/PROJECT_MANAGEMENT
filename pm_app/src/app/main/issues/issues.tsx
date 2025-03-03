import { Badge } from "@/components/ui/badge";
import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { useGetIssues } from "@/features/issues/api/use-get-issue";
import { IssuePriority, IssueStatus } from "@/features/issues/enums";
import { Plus } from "lucide-react";
import { useNavigate, useParams } from "react-router-dom";

function IssuesPage() {
  const navigate = useNavigate()
  const { data } = useGetIssues({me: true});
  return (
    <div className="w-full">
      <div className="flex justify-between mb-4">
        <h1 className="text-3xl font-bold">Danh sách công việc của bạn</h1>
        <Button className="bg-blue-700" size={"lg"}>
          <Plus /> Tạo công việc
        </Button>
      </div>
      <div className="grid grid-cols-1 gap-4">
        {data?.issues.map((i) => (
          <Card className=" hover:cursor-pointer hover:bg-gray-700/10" key={i.id} onClick={()=> {
            navigate(i.id)
          }}>
            <CardHeader className="flex flex-row justify-between">
              <div className="w-9/12 overflow-hidden">
                <CardTitle className="">
                <span className="text-2xl font-semibold">{i.title}</span>
                </CardTitle>
              <CardDescription className="text-2xl font-semibold">{i.code}</CardDescription>
              </div>
              <div className="">
              <Badge>{IssuePriority[i.priority]}</Badge>
              <Badge>{IssueStatus[i.status]}</Badge>
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
