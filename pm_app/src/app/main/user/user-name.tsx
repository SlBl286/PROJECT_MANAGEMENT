import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import { useParams } from "react-router-dom";


function UserNamePage() {
    const {username} = useParams();
  return (
    <div className="flex justify-center items-center w-screen h-screen">
      <Card className="w-[400px]">
        <CardHeader>
          <CardTitle>aaaa </CardTitle>
        </CardHeader>
        <CardContent>
            {username}
        </CardContent>
       
      </Card>
    </div>
  );
}

export default UserNamePage;
