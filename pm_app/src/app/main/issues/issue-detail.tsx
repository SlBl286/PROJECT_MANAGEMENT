import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { Bug } from "lucide-react";
import { useParams } from "react-router-dom";

function IssueDetailPage() {
  const { issueId } = useParams();
  return (
    <div className="grid grid-cols-3 gap-4">
      <div className="col-span-3">
      <Card>
          <CardHeader>
            <CardTitle>Dự án : ABC</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="space-y-4"></div>
          </CardContent>
        </Card>
      </div>
      <div className="col-span-2">
        <Card>
          <CardHeader>
            <CardTitle>Hoạt động mới nhất</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="space-y-4"></div>
          </CardContent>
        </Card>
      </div>
      <div className="grid grid-rows gap-4">
        <div className="">
        <Card>
          <CardHeader>
            <CardTitle>Thành viên</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="space-y-4"></div>
          </CardContent>
        </Card>
        </div>
        <div className="">
        <Card>
          <CardHeader>
            <CardTitle>Công việc</CardTitle>
          </CardHeader>
          <CardContent>
            <div className="space-y-4">
              <Bug className="bg-red-600 p-1 rounded-sm text-white"/>
            </div>
          </CardContent>
        </Card>
        </div>
      </div>
    </div>
  );
}

export default IssueDetailPage;
