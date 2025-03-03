import z from "zod";
import { IssuePriority, IssueType } from "./enums";
export const createIssueSchema = z.object({
  title: z.string().trim(),
  description: z.string().optional(),
  priority: z.nativeEnum(IssuePriority),
  type: z.nativeEnum(IssueType),
  assigneeId: z.string(),
  projectId: z.string(),
});
