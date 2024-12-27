import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"
import { Progress } from "@/components/ui/progress"

export function ProjectStats() {
  const projects = [
    { name: "Project Alpha", progress: 75 },
    { name: "Project Beta", progress: 50 },
    { name: "Project Gamma", progress: 25 },
  ]

  return (
    <Card>
      <CardHeader>
        <CardTitle>Project Stats</CardTitle>
      </CardHeader>
      <CardContent>
        <div className="space-y-4">
          {projects.map((project) => (
            <div key={project.name} className="space-y-2">
              <div className="flex items-center justify-between">
                <p className="text-sm font-medium">{project.name}</p>
                <p className="text-sm text-muted-foreground">{project.progress}%</p>
              </div>
              <Progress value={project.progress} />
            </div>
          ))}
        </div>
      </CardContent>
    </Card>
  )
}

