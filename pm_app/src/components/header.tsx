import { Bell, Plus, Search, Settings } from "lucide-react";
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
export function Header() {
  return (
    <header className="border-b">
      <div className="container mx-auto flex h-16 items-center px-4">
        <a href="/" className="flex items-center space-x-2">
          <img src={favicon} width={30} />
        </a>
        <nav className="mx-6 flex items-center space-x-4 lg:space-x-6">
          <a
            href="/dashboard"
            className="text-sm font-medium text-blue-700 transition-colors hover:text-primary"
          >
            Dashboard
          </a>
          <a
            href="/projects"
            className="text-sm font-medium text-muted-foreground transition-colors hover:text-primary"
          >
            Projects
          </a>
          <a
            href="/issues"
            className="text-sm font-medium text-muted-foreground transition-colors hover:text-primary"
          >
            Issues
          </a>
          <DropdownMenu>
            <DropdownMenuTrigger asChild>
                <Button className="bg-blue-700">
              <Plus />
              Tạo mới
                </Button>
            </DropdownMenuTrigger>
            <DropdownMenuContent>
              <DropdownMenuItem>Issue</DropdownMenuItem>
              <DropdownMenuItem>Project</DropdownMenuItem>
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
          <ModeToggle/>
          <UserMenu />
        </div>
      </div>
    </header>
  );
}
