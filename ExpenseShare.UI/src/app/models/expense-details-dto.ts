export interface ExpenseDetailsDto {
    id: string;
    description: string;
    amount: number;
    groupId: string;
    groupName: string;
    paidByMemberId: string;
    paidBy: string;
    splitAmongMemberIds: string[];
    splitAmong: string[];
}
