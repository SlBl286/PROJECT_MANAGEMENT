import { create } from "zustand";

type CreateProjectModalStore = {
  isOpen: boolean;
  setIsOpen: (value: boolean) => void;
  open: () => void;
  close: () => void;
  toggle: () => void;
};

export const useCreateProjectModal = create<CreateProjectModalStore>((set) => ({
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
