import { useQuery } from "@tanstack/react-query";
import api from "../../../api/api";
import { Users } from "../types";
type UseGetUsersProps = {
  includeMe : boolean
}
export const useGetUsers = ({includeMe}: UseGetUsersProps) => {
  const query = useQuery<any,Error,Users>({
    queryKey: ["users"],
    queryFn: async () => {
      try {
        const respone = await api.get<Users>("/Users",{params: {includeMe}});
        if (respone.status !== 200) {
          return null;
        }
        console.log(respone)
        const data = respone.data;
        return data;
      } catch (error) {
        return null;
      }
    },
  });

  return query;
};
