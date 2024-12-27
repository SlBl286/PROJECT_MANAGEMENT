import { Button } from "@/components/ui/button";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import LoginForm from "@/features/auth/components/login-form";
import { useNavigate } from "react-router-dom";

function LoginPage() {
  const navigate = useNavigate();
  const onRegisterClick = ()=>{
    navigate("/auth/register")
  }
  return <Card className="md:w-[400px] w-full mx-2 md:mx-0">
    <CardHeader className="flex justify-center ">
      <CardTitle className="text-2xl font-semibold">
        Đăng nhập hệ thống
      </CardTitle>
    </CardHeader>
    <CardContent>
      <LoginForm />
    </CardContent>
    <CardFooter className="flex items-center justify-center gap-x-0">
        Chưa có tài khoản?
      <Button variant={"link"} className="ml-[-10px] text-blue-500" onClick={onRegisterClick}>Đăng ký </Button>
    </CardFooter>
  </Card>;
}

export default LoginPage;
