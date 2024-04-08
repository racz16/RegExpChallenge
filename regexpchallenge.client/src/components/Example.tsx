import { ChallengeExampleDto } from '../dtos/ChallengeExampleDto';

interface ContentSegment {
    id: string;
    text: string;
    match: boolean;
    index: number;
}

interface ExampleProps {
    example: ChallengeExampleDto;
    isEditable: boolean;
    isEditing: boolean;
    isRemovable: boolean;
    regexp?: RegExp;
    togglePreviewEdit: (id: number) => void;
    remove: (id: number) => void;
    input: (id: number, text: string) => void;
}

export function Example({ example, isEditable, isEditing, isRemovable, regexp, togglePreviewEdit, remove, input }: ExampleProps) {
    const contentSegments: ContentSegment[] = [];
    if (regexp) {
        const regexpResults = example.example.matchAll(regexp);
        let lastEnd = 0;
        for (const regexpResult of regexpResults) {
            if (regexpResult.index) {
                contentSegments.push({
                    id: `${example.id}:${lastEnd}:${regexpResult.index - lastEnd}`,
                    text: example.example.substring(lastEnd, regexpResult.index),
                    match: false,
                    index: -1,
                });
            }
            contentSegments.push({
                id: `${example.id}:${regexpResult.index}:${regexpResult[0].length}`,
                text: regexpResult[0],
                match: true,
                index: regexpResult.index,
            });
            lastEnd = regexpResult.index! + regexpResult[0].length;
        }
        if (lastEnd !== example.example.length - 1)
            contentSegments.push({
                id: `${example.id}:${lastEnd}:${example.example.length - 1}`,
                text: example.example.substring(lastEnd),
                match: false,
                index: -1,
            });
    }
    const matches = contentSegments.filter((cs) => cs.match);

    return (
        <div className="card d-flex flex-row justify-content-between align-items-center p-3">
            {isEditable && isEditing ? (
                <textarea
                    value={example.example}
                    onChange={(e) => {
                        input(example.id, e.target.value);
                    }}
                    className="flex-grow-1"
                ></textarea>
            ) : contentSegments.length ? (
                <span key={`${example.id}:${example.example}:div`}>
                    {contentSegments.map((res) => (
                        <span className={res.match ? 'match border border-primary' : ''} id={res.id} key={res.id}>
                            {res.text}
                        </span>
                    ))}
                </span>
            ) : (
                <span>{example.example}</span>
            )}
            {isEditable ? (
                <div>
                    <button className="btn btn-outline-primary ms-2" onClick={() => togglePreviewEdit(example.id)}>
                        {isEditing ? 'Preview' : 'Edit'}
                    </button>
                    <button className="btn btn-outline-danger ms-2" disabled={!isRemovable} onClick={() => remove(example.id)}>
                        Remove
                    </button>
                </div>
            ) : (
                <div>
                    {regexp &&
                    example.matches.length === matches.length &&
                    matches.every((m) => example.matches.some((m2) => m.index === m2.index && m.text.length === m2.length)) ? (
                        <div className="status-circle text-bg-success rounded-circle"></div>
                    ) : (
                        <div className="status-circle text-bg-danger rounded-circle"></div>
                    )}
                </div>
            )}
        </div>
    );
}
