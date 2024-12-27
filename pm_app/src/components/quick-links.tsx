import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Button } from "@/components/ui/button"
import { PlusCircle, ClipboardList, BarChart2, Settings } from 'lucide-react'

export function QuickLinks() {
  const links = [
    { name: "Create Issue", icon: PlusCircle },
    { name: "My Work", icon: ClipboardList },
    { name: "Reports", icon: BarChart2 },
    { name: "Project Settings", icon: Settings },
  ]

  return (
    <Card>
      <CardHeader>
        <CardTitle>Quick Links</CardTitle>
      </CardHeader>
      <CardContent>
        <div className="grid grid-cols-2 gap-4">
          {links.map((link) => (
            <Button key={link.name} variant="outline" className="h-20 w-full">
              <div className="flex flex-col items-center justify-center space-y-2">
                <link.icon className="h-6 w-6" />
                <span className="text-xs">{link.name}</span>
              </div>
            </Button>
          ))}
        </div>
      </CardContent>
    </Card>
  )
}

