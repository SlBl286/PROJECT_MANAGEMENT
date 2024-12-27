import { Button } from "@/components/ui/button";
import { useNavigate } from "react-router-dom";


function NotFoundPage() {
  const navigate = useNavigate()
  return (
    <div className="flex flex-col justify-center items-center w-screen h-screen gap-4">
      <div className="text-6xl font-semibold">
        Page Not Found
      </div>
      <Button variant={"secondary"} size="lg" onClick={()=>{navigate("/")}}>Go back to home</Button>
    </div>
  );
}

export default NotFoundPage;
