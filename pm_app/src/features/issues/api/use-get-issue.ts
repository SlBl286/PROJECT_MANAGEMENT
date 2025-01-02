import { useQuery } from "@tanstack/react-query";
import api from "../../../api/api";
import { Issue } from "../types";
type UseGetIssuesProps = {
  userId : string
}
export const useGetIssues= ({userId}: UseGetIssuesProps) => {
  const query = useQuery({
    queryKey: ["issues",userId],
    queryFn: async () => {
      try {
        const respone = await api.get<Issue[]>("/issues",{params: {userId}})
        if (respone.statusText !== "OK") {
          return null;
      }
        const data = respone.data
        return data;
      } catch (error) {
        return null;
      }
    },
  });

  return query;
};
