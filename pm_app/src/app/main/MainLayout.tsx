import { Outlet } from "react-router-dom";
import { Header } from "@/components/header";


export default function MainLayout() {
  
  return (
    <div className="min-h-screen bg-background w-screen">
      <Header />
      <main className="container mx-auto p-4 md:p-6">
       <Outlet/>
      </main>
    </div>
  );
}
