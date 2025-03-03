import { useQuery } from "@tanstack/react-query";
import api from "../../../api/api";
import { Project } from "../types";
type UseGetItemsProps = {
  projectId : string
}
export const useGetProject= ({projectId}: UseGetItemsProps) => {
  const query = useQuery({
    queryKey: ["projects",projectId],
    queryFn: async () => {
      try {
        const respone = await api.get<Project>(`/projects/${projectId}`)
        console.log(respone)
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
