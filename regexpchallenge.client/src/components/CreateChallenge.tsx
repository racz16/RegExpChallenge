import { useState } from 'react';
import { Example } from './Example';
import { Link } from 'react-router-dom';
import { ChallengeExampleDto } from '../dtos/ChallengeExampleDto';

let nextId = 1;

export default function CreateChallenge() {
    const [regexpInput, setRegexpInput] = useState('\\w+');
    const [editableExample, setEditableExample] = useState(-1);
    const [examples, setExamples] = useState<ChallengeExampleDto[]>([{ id: nextId++, example: 'This is a test example', matches: [] }]);
    const [blured, setBlured] = useState(false);

    let regexp: RegExp | undefined;
    try {
        regexp = new RegExp(regexpInput, 'g');
    } catch (e) {
        // regexp remains undefined which means it's invalid
    }

    function togglePreviewEdit(id: number): void {
        setEditableExample(editableExample === id ? -1 : id);
    }

    function remove(id: number): void {
        setExamples([...examples.filter((ex) => id !== ex.id)]);
    }

    function input(id: number, text: string): void {
        setExamples((examples) => examples.map((ex) => (id !== ex.id ? { ...ex } : { ...ex, text })));
    }

    function blurInput(): void {
        setBlured(true);
    }

    return (
        <>
            <h2>Create challenge</h2>
            <form className="d-flex flex-column gap-2">
                <div className="d-flex flex-column">
                    <label htmlFor="name">Name</label>
                    <input required id="name" onBlur={blurInput} />
                    {blured && <div className="text-danger">Name is required</div>}
                </div>
                <div className="d-flex flex-column">
                    <label htmlFor="description">Description</label>
                    <textarea id="description"></textarea>
                </div>
                <div className="d-flex flex-column">
                    <label htmlFor="regexp">Regular expression</label>
                    <input
                        id="regexp"
                        value={regexpInput}
                        onChange={(e) => {
                            setRegexpInput(e.target.value);
                        }}
                    />
                    {!regexp && <div className="text-danger">Invalid regular expression</div>}
                </div>
                <div className="d-flex justify-content-between align-items-center mt-2">
                    <label>Examples</label>
                    <button
                        className="btn btn-outline-primary"
                        onClick={() => {
                            setEditableExample(-1);
                            setExamples([...examples, { id: nextId++, example: 'Test', matches: [] }]);
                        }}
                    >
                        Add
                    </button>
                </div>
                {examples.map((example) => {
                    return (
                        <Example
                            key={example.id}
                            example={example}
                            isEditable={true}
                            isEditing={editableExample === example.id}
                            isRemovable={examples.length > 1}
                            regexp={regexp}
                            togglePreviewEdit={togglePreviewEdit}
                            remove={remove}
                            input={input}
                        />
                    );
                })}
            </form>
            <div className="d-flex justify-content-end mt-2">
                <Link className="btn btn-outline-secondary" to="/">
                    Cancel
                </Link>
                <button className="btn btn-primary ms-2">Save</button>
            </div>
        </>
    );
}
