import { Option } from './Option';

export class Question {
    QuestionId: number;
    ProblemStatement: string;
    Options: Option[];
    ResourceLink: string;
    BloomLevel: number;
}

