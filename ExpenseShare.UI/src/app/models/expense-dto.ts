export interface ExpenseDto {
    description: string;
    amount: number;
    groupId: string;
    paidByMemberId: string;
    splitAmongMemberIds: string[];
}
