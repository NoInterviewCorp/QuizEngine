export class Option
{
    id: number;
    questionId: number;
    content: string;
    isAnswer: boolean;
    selected: boolean;

    constructor(data: any) {
        data = data || {};
        this.id = data.id;
        this.questionId = data.questionId;
        this.content = data.content;
        this.isAnswer = data.isAnswer;
    }
}