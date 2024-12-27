import { ModeToggle } from "@/components/mode-tggle";
import { Outlet } from "react-router-dom";
import logo from "@/assets/logo.svg"
const AuthLayout = () => {
  return (
    <div className="flex justify-center items-center w-screen h-screen">
      <div className="fixed top-4 right-4">
        <ModeToggle />
      </div>
      <div className="flex-col justify-center items-center">
      <div className="mb-4 flex items-center justify-center">
        <img src={logo}/>
      </div>
      <Outlet/>
      </div>
    </div>
  );
};

export default AuthLayout;
