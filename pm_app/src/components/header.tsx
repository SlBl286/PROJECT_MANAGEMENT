import { Bell, Menu, Plus, Search, Settings } from "lucide-react";
import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import { UserMenu } from "@/components/user-menu";
import favicon from "@/assets/favicon.svg";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuTrigger,
} from "./ui/dropdown-menu";
import { ModeToggle } from "./mode-tggle";
import { CreateProjectModal } from "@/features/projects/components/create-project-modal";
import { CreateIssueModal } from "@/features/issues/components/create-issue-modal";
import { cn } from "@/lib/utils";
import { useLocation } from "react-router-dom";
import {
  Sheet,
  SheetContent,
  SheetDescription,
  SheetHeader,
  SheetTitle,
  SheetTrigger,
} from "./ui/sheet";
export function Header() {
  const location = useLocation();
  return (
    <header className="border-b">
      <div className="container mx-auto flex h-16 items-center px-4">
        <a href="/" className="flex items-center space-x-2">
          <img src={favicon} width={30} />
        </a>
        <div className="flex md:hidden ml-2">
          <Sheet>
            <SheetTrigger asChild>
              <Button variant={"outline"}>

              <Menu />
              </Button>
            </SheetTrigger>
            <SheetContent side={"left"} className="w-[250px]">
              <SheetHeader>
                <SheetTitle>Quản lý tiến độ dự án</SheetTitle>
              </SheetHeader>
    <div className="flex flex-col">
    <a
              href="/dashboard"
              className={cn(
                location.pathname === "/dashboard"
                  ? "text-blue-700"
                  : "text-muted-foreground",
                "text-sm font-medium  transition-colors hover:text-primary"
              )}
            >
              Dashboard
            </a>
            <a
              href="/projects"
              className={cn(
                location.pathname === "/projects"
                  ? "text-blue-700"
                  : "text-muted-foreground",
                "text-sm font-medium  transition-colors hover:text-primary"
              )}
            >
              Dự án
            </a>
            <a
              href="/issues"
              className={cn(
                location.pathname === "/issues"
                  ? "text-blue-700"
                  : "text-muted-foreground",
                "text-sm font-medium  transition-colors hover:text-primary"
              )}
            >
              Công việc
            </a>
    </div>
            </SheetContent>
          </Sheet>
        </div>
        <nav className="lg:ml-4 items-center space-x-4 lg:space-x-6 flex">
          <div className=" hidden md:flex space-x-4 lg:space-x-6">
            <a
              href="/dashboard"
              className={cn(
                location.pathname === "/dashboard"
                  ? "text-blue-700"
                  : "text-muted-foreground",
                "text-sm font-medium  transition-colors hover:text-primary"
              )}
            >
              Dashboard
            </a>
            <a
              href="/projects"
              className={cn(
                location.pathname === "/projects"
                  ? "text-blue-700"
                  : "text-muted-foreground",
                "text-sm font-medium  transition-colors hover:text-primary"
              )}
            >
              Dự án
            </a>
            <a
              href="/issues"
              className={cn(
                location.pathname === "/issues"
                  ? "text-blue-700"
                  : "text-muted-foreground",
                "text-sm font-medium  transition-colors hover:text-primary"
              )}
            >
              Công việc
            </a>
          </div>
          <DropdownMenu>
            <DropdownMenuTrigger asChild>
              <Button className="bg-blue-700">
                <Plus />
                <span className="hidden md:flex">

                Tạo mới
                </span>
              </Button>
            </DropdownMenuTrigger>
            <DropdownMenuContent>
              <DropdownMenuItem asChild>
                <CreateProjectModal />
              </DropdownMenuItem>
              <DropdownMenuItem asChild>
                <CreateIssueModal />
              </DropdownMenuItem>
            </DropdownMenuContent>
          </DropdownMenu>
        </nav>
   
        <div className="ml-auto flex items-center space-x-4">
          <form className="hidden lg:block">
            <div className="relative">
              <Search className="absolute left-2.5 top-2.5 h-4 w-4 text-muted-foreground" />
              <Input
                type="search"
                placeholder="Search..."
                className="w-[200px] pl-8 sm:w-[300px]"
              />
            </div>
          </form>
          <Button size="icon" variant="ghost">
            <Bell className="h-5 w-5" />
            <span className="sr-only">Notifications</span>
          </Button>
          <ModeToggle />
          <UserMenu />
        </div>
      </div>
    </header>
  );
}
