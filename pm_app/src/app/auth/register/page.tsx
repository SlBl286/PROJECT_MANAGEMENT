import { Button } from "@/components/ui/button";
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import RegisterForm from "@/features/auth/components/register-form";
import { useNavigate } from "react-router-dom";

function RegisterPage() {
  const navigate = useNavigate();
  const onLoginClick = () => {
    navigate("/auth/login");
  };
  return (
    <Card className="md:w-[500px]  w-full mx-2 md:mx-0">
      <CardHeader className="flex justify-center ">
        <CardTitle className="text-2xl font-semibold">
          Đăng ký tài khoản
        </CardTitle>
      </CardHeader>
      <CardContent>
        <RegisterForm />
      </CardContent>
      <CardFooter className="flex items-center justify-center gap-x-0">
        Đã có tài khoản?
        <Button
          variant={"link"}
          className="ml-[-10px] text-blue-500"
          onClick={onLoginClick}
        >
          Đăng nhập{" "}
        </Button>
      </CardFooter>
    </Card>
  );
}

export default RegisterPage;
