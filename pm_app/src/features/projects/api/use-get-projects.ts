import { useQuery } from "@tanstack/react-query";
import api from "../../../api/api";
import { Projects } from "../types";
type UseGetItemsProps = {
}
export const useGetProjects= ({}: UseGetItemsProps) => {
  const query = useQuery({
    queryKey: ["projects"],
    queryFn: async () => {
      try {
        const respone = await api.get<Projects>("/projects",{})
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
