import { useQuery } from "@tanstack/react-query";
import api from "../../../api/api";
import { Project } from "../types";
type UseGetItemsProps = {
    keyword : string;
    categoryId : string | null;
}
export const useGetItems= ({keyword,categoryId}: UseGetItemsProps) => {
  const query = useQuery({
    queryKey: ["projects",keyword,categoryId],
    queryFn: async () => {
      try {
        const respone = await api.get<Project[]>("/projects",{params: {keyword,categoryId}})
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
