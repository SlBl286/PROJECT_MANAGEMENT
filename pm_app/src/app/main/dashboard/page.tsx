import { Header } from "@/components/header"
import { AssignedIssues } from "@/components/assigned-issues"
import { RecentActivity } from "@/components/recent-activity"
import { ProjectStats } from "@/components/project-stats"
import { QuickLinks } from "@/components/quick-links"

export default function Dashboard() {
  return (
    <div>
       <h1 className="text-3xl font-bold mb-6">Dashboard</h1>
        <div className="grid gap-6 md:grid-cols-2 lg:grid-cols-2">
          <RecentActivity />
          <AssignedIssues />
          <ProjectStats />
          <QuickLinks />
        </div>
    </div>
  )
}

