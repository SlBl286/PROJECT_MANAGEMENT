import { useQuery } from "@tanstack/react-query";
import api from "../../../api/api";
import { Members } from "../types";
type UseGetMembersProps = {
  projectId : string
}
export const useGetMembers = ({projectId}: UseGetMembersProps) => {
  const query = useQuery<any,Error,Members>({
    queryKey: ["members",projectId],
    queryFn: async () => {
      try {
        const response = await api.get<Members>(`/projects/${projectId}/Members`);
        if (response.status !== 200) {
          return undefined;
        }
        const data = response.data;
        return data;
      } catch (error) {
        return undefined;
      }
    },
  });

  return query;
};
