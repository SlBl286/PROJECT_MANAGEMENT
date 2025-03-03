import { create } from "zustand";

type CreateIssueModalStore = {
  isOpen: boolean;
  setIsOpen: (value: boolean) => void;
  open: () => void;
  close: () => void;
  toggle: () => void;
};

export const useCreateIssueModal = create<CreateIssueModalStore>((set) => ({
  isOpen: false,
  setIsOpen: (value) => {
    set(() => ({ isOpen: value }));
  },
  open: () => {
    set(() => ({ isOpen: true }));
  },
  close: () => {
    set(() => ({ isOpen: false }));
  },
  toggle: () => {
    set((state) => ({ isOpen: !state.isOpen }));
  },
}));
