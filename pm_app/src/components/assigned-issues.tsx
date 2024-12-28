import { Card, CardContent, CardDescription, CardHeader, CardTitle } from "@/components/ui/card"
import { Badge } from "@/components/ui/badge"

export function AssignedIssues() {
  const issues = [
    { id: "PROJ-1", title: "Implement login functionality", priority: "High" },
    { id: "PROJ-2", title: "Fix navigation bug", priority: "Medium" },
    { id: "PROJ-3", title: "Update user documentation", priority: "Low" },
  ]

  return (
    <Card>
      <CardHeader>
        <CardTitle>Assigned Issues</CardTitle>
        <CardDescription></CardDescription>
      </CardHeader>
      <CardContent>
        <ul className="space-y-4">
          {issues.map((issue) => (
            <li key={issue.id} className="flex items-center justify-between">
              <div>
                <p className="font-medium">{issue.title}</p>
                <p className="text-sm text-muted-foreground">{issue.id}</p>
              </div>
              <Badge
                variant={
                  issue.priority === "High"
                    ? "destructive"
                    : issue.priority === "Medium"
                    ? "default"
                    : "secondary"
                }
              >
                {issue.priority}
              </Badge>
            </li>
          ))}
        </ul>
      </CardContent>
    </Card>
  )
}

