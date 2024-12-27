import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card"

export function RecentActivity() {
  const activities = [
    { id: 1, user: "John Doe", action: "commented on", item: "PROJ-1" },
    { id: 2, user: "Jane Smith", action: "closed", item: "PROJ-5" },
    { id: 3, user: "Mike Johnson", action: "created", item: "PROJ-8" },
  ]

  return (
    <Card>
      <CardHeader>
        <CardTitle>Recent Activity</CardTitle>
      </CardHeader>
      <CardContent>
        <ul className="space-y-4">
          {activities.map((activity) => (
            <li key={activity.id} className="flex items-center space-x-4">
              <div className="rounded-full bg-primary/10 p-2">
                <span className="text-xs font-bold text-primary">
                  {activity.user.split(" ").map((n) => n[0]).join("")}
                </span>
              </div>
              <div>
                <p className="text-sm">
                  <span className="font-medium">{activity.user}</span>{" "}
                  {activity.action}{" "}
                  <span className="font-medium">{activity.item}</span>
                </p>
              </div>
            </li>
          ))}
        </ul>
      </CardContent>
    </Card>
  )
}

